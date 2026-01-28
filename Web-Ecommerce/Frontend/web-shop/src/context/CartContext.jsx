import { createContext, useState, useEffect, useContext } from 'react';

const CartContext = createContext();

export const CartProvider = ({ children }) => {
    const [cartItems, setCartItems] = useState(() => {
        const storedCart = localStorage.getItem('cartItems');
        return storedCart ? JSON.parse(storedCart) : [];
    });

    useEffect(() => {
        localStorage.setItem('cartItems', JSON.stringify(cartItems));
    }, [cartItems]);

    // --- SỬA LOGIC ADD TO CART ---
    const addToCart = (product, quantity = 1, variant = {}) => {
        setCartItems((prevItems) => {
            // 1. Tạo một ID duy nhất cho dòng sản phẩm này trong giỏ hàng
            // Ví dụ: "101-XL-Red" hoặc "101-null-null" (nếu ko có variant)
            const uniqueCartId = `${product.id}-${variant.size || ''}-${variant.color || ''}`;

            // 2. Tìm xem trong giỏ đã có ID duy nhất này chưa
            const itemExists = prevItems.find((item) => item.cartId === uniqueCartId);

            if (itemExists) {
                // Nếu trùng cả ID, Size, Color -> Cộng dồn số lượng
                return prevItems.map((item) =>
                    item.cartId === uniqueCartId
                        ? { ...item, quantity: item.quantity + quantity }
                        : item
                );
            } else {
                // Nếu khác Size hoặc Color -> Thêm dòng mới
                return [...prevItems, { 
                    ...product, 
                    cartId: uniqueCartId, // Quan trọng: Lưu ID định danh này
                    quantity: quantity, 
                    selectedSize: variant.size, 
                    selectedColor: variant.color 
                }];
            }
        });
        alert("Đã thêm vào giỏ hàng thành công!");
    };

    // --- SỬA LOGIC XÓA (Xóa theo cartId thay vì productId) ---
    const removeFromCart = (cartId) => {
        setCartItems((prevItems) => prevItems.filter((item) => item.cartId !== cartId));
    };

    // --- SỬA LOGIC UPDATE SỐ LƯỢNG (Theo cartId) ---
    const updateQuantity = (cartId, amount) => {
        setCartItems((prevItems) =>
            prevItems.map((item) =>
                item.cartId === cartId
                    ? { ...item, quantity: Math.max(1, item.quantity + amount) } 
                    : item
            )
        );
    };

    const totalPrice = cartItems.reduce((total, item) => {
        const price = Number(item.price) || 0;
        const qty = Number(item.quantity) || 1;
        return total + (price * qty);
    }, 0);

    return (
        <CartContext.Provider value={{ cartItems, addToCart, removeFromCart, updateQuantity, totalPrice }}>
            {children}
        </CartContext.Provider>
    );
};

export const useCart = () => useContext(CartContext);