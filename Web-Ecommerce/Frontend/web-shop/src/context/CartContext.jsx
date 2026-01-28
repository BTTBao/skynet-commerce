import { createContext, useState, useEffect, useContext } from 'react';

const CartContext = createContext();

export const CartProvider = ({ children }) => {
    const [cartItems, setCartItems] = useState(() => {
        const storedCart = localStorage.getItem('cartItems');
        return storedCart ? JSON.parse(storedCart) : [];
    });

    // Tự động lưu vào LocalStorage mỗi khi cartItems thay đổi
    useEffect(() => {
        localStorage.setItem('cartItems', JSON.stringify(cartItems));
    }, [cartItems]);

    // --- LOGIC ADD TO CART ---
    const addToCart = (product, quantity = 1, variant = {}) => {
        setCartItems((prevItems) => {
            // 1. Tạo ID duy nhất: ID sp + Size + Color
            const uniqueCartId = `${product.id}-${variant.size || ''}-${variant.color || ''}`;

            // 2. Kiểm tra tồn tại
            const itemExists = prevItems.find((item) => item.cartId === uniqueCartId);

            if (itemExists) {
                // Cộng dồn số lượng
                return prevItems.map((item) =>
                    item.cartId === uniqueCartId
                        ? { ...item, quantity: item.quantity + quantity }
                        : item
                );
            } else {
                // Thêm mới
                return [...prevItems, { 
                    ...product, 
                    cartId: uniqueCartId, 
                    quantity: quantity, 
                    selectedSize: variant.size, 
                    selectedColor: variant.color 
                }];
            }
        });
        alert("Đã thêm vào giỏ hàng thành công!");
    };

    // --- LOGIC XÓA ---
    const removeFromCart = (cartId) => {
        setCartItems((prevItems) => prevItems.filter((item) => item.cartId !== cartId));
    };

    // --- LOGIC UPDATE SỐ LƯỢNG ---
    const updateQuantity = (cartId, amount) => {
        setCartItems((prevItems) =>
            prevItems.map((item) =>
                item.cartId === cartId
                    ? { ...item, quantity: Math.max(1, item.quantity + amount) } 
                    : item
            )
        );
    };

    // --- LOGIC CLEAR CART (Dọn sạch giỏ hàng) ---
    // <--- THÊM MỚI TẠI ĐÂY
    const clearCart = () => {
        setCartItems([]); 
    };

    // --- TÍNH TỔNG TIỀN ---
    const totalPrice = cartItems.reduce((total, item) => {
        const price = Number(item.price) || 0;
        const qty = Number(item.quantity) || 1;
        return total + (price * qty);
    }, 0);

    return (
        // Nhớ thêm clearCart vào value
        <CartContext.Provider value={{ cartItems, addToCart, removeFromCart, updateQuantity, clearCart, totalPrice }}>
            {children}
        </CartContext.Provider>
    );
};

export const useCart = () => useContext(CartContext);