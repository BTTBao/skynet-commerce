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

    // SỬA 1: Nhận thêm tham số quantity và biến thể (size, color)
    const addToCart = (product, quantity = 1, variant = {}) => {
        setCartItems((prevItems) => {
            // Kiểm tra xem sản phẩm (cùng ID và cùng Size/Màu) đã có chưa
            // Lưu ý: Để đơn giản, ở đây mình check theo ID. 
            // Nếu muốn chuyên sâu check theo size/color thì cần so sánh kỹ hơn.
            const itemExists = prevItems.find((item) => item.id === product.id);

            if (itemExists) {
                return prevItems.map((item) =>
                    item.id === product.id 
                        ? { ...item, quantity: item.quantity + quantity } // Cộng dồn số lượng
                        : item
                );
            } else {
                return [...prevItems, { 
                    ...product, 
                    quantity: quantity, 
                    selectedSize: variant.size,   // Lưu thêm Size
                    selectedColor: variant.color  // Lưu thêm Màu
                }];
            }
        });
        alert("Đã thêm vào giỏ hàng thành công!");
    };

    const removeFromCart = (id) => {
        setCartItems((prevItems) => prevItems.filter((item) => item.id !== id));
    };

    const updateQuantity = (id, amount) => {
        setCartItems((prevItems) =>
            prevItems.map((item) =>
                item.id === id 
                    ? { ...item, quantity: Math.max(1, item.quantity + amount) } 
                    : item
            )
        );
    };

    // SỬA 2: Ép kiểu Number để đảm bảo tính toán đúng
    const totalPrice = cartItems.reduce((total, item) => {
        const price = Number(item.price) || 0; // Chuyển chuỗi thành số, nếu lỗi thì về 0
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