import { createContext, useState, useEffect, useContext } from 'react';

const CartContext = createContext();

export const CartProvider = ({ children }) => {
    const [cartItems, setCartItems] = useState(() => {
        const storedCart = localStorage.getItem('cartItems');
        return storedCart ? JSON.parse(storedCart) : [];
    });

    // Tự động lưu LocalStorage
    useEffect(() => {
        localStorage.setItem('cartItems', JSON.stringify(cartItems));
    }, [cartItems]);

    // ==================================================================
    // 1. THÊM TÍNH NĂNG: LÀM MỚI DỮ LIỆU (Re-validate)
    // Gọi hàm này khi vào trang CartPage để đảm bảo Status mới nhất từ DB
    // ==================================================================
    const refreshCartData = async () => {
        if (cartItems.length === 0) return;

        try {
            // Cách đơn giản: Lấy lại danh sách Product từ API
            // (Tốt hơn là nên có API: POST /api/cart/validate gửi list ID lên check)
            const response = await fetch("http://localhost:5198/api/Products"); 
            if (response.ok) {
                const allProducts = await response.json();

                setCartItems(prevItems => {
                    return prevItems.map(cartItem => {
                        // Tìm sản phẩm tương ứng trong DB mới nhất
                        const liveProduct = allProducts.find(p => p.productId === (cartItem.productId || cartItem.id));
                        
                        if (liveProduct) {
                            // Cập nhật lại Status và Giá (đề phòng giá đổi luôn)
                            return {
                                ...cartItem,
                                status: liveProduct.status || liveProduct.Status, // Cập nhật Status mới nhất
                                price: liveProduct.price || liveProduct.Price     // Cập nhật Giá mới nhất
                            };
                        }
                        return cartItem;
                    });
                });
            }
        } catch (error) {
            console.error("Không thể làm mới giỏ hàng:", error);
        }
    };

    const addToCart = (product, quantity = 1, variant = {}) => {
        // [MỚI] Validate số lượng đầu vào
        const qty = Number(quantity); // Đảm bảo là số
        if (qty <= 0) {
            alert("Vui lòng chọn số lượng ít nhất là 1!");
            return;
        }

        setCartItems((prevItems) => {
            const uniqueCartId = `${product.id || product.productId}-${variant.size || ''}-${variant.color || ''}`;
            const itemExists = prevItems.find((item) => item.cartId === uniqueCartId);

            const productStatus = product.status || product.Status || 'Active';

            if (itemExists) {
                return prevItems.map((item) =>
                    item.cartId === uniqueCartId
                        ? { ...item, quantity: item.quantity + qty } // Cộng dồn số lượng chuẩn
                        : item
                );
            } else {
                return [...prevItems, { 
                    ...product, 
                    id: product.id || product.productId,
                    status: productStatus,
                    cartId: uniqueCartId, 
                    quantity: qty, // Dùng số lượng chuẩn
                    selectedSize: variant.size, 
                    selectedColor: variant.color 
                }];
            }
        });
        alert("Đã thêm vào giỏ hàng thành công!");
    };

    // --- REMOVE ---
    const removeFromCart = (cartId) => {
        setCartItems((prevItems) => prevItems.filter((item) => item.cartId !== cartId));
    };

    // --- UPDATE QUANTITY ---
    const updateQuantity = (cartId, amount) => {
        setCartItems((prevItems) =>
            prevItems.map((item) =>
                item.cartId === cartId
                    ? { ...item, quantity: Math.max(1, item.quantity + amount) } 
                    : item
            )
        );
    };

    // --- CLEAR CART ---
    const clearCart = () => {
        setCartItems([]); 
    };

    // --- TOTAL PRICE ---
    const totalPrice = cartItems.reduce((total, item) => {
        const price = Number(item.price) || 0;
        const qty = Number(item.quantity) || 1;
        // Chỉ tính tiền sản phẩm KHÔNG bị ẩn (Tùy logic shop bạn)
        // Nếu muốn tính hết thì bỏ điều kiện status này đi
        if (item.status === 'Hidden') return total; 
        
        return total + (price * qty);
    }, 0);

    return (
        <CartContext.Provider value={{ 
            cartItems, 
            addToCart, 
            removeFromCart, 
            updateQuantity, 
            clearCart, 
            totalPrice,
            refreshCartData // <--- Export thêm hàm này
        }}>
            {children}
        </CartContext.Provider>
    );
};

export const useCart = () => useContext(CartContext);