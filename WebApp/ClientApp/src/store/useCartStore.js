import { create } from "zustand";

const INITIAL_STATE = {
  cart: [
    { id: 1, name: "کینگ برگر", price: 269000, quantity: 1 },
    { id: 2, name: "کینگ برگر", price: 269000, quantity: 1 },
  ],
  totalItems: 0,
  totalPrice: 0,
};

export const useCartStore = create((set, get) => ({
  cart: INITIAL_STATE.cart,
  totalItems: INITIAL_STATE.totalItems,
  totalPrice: INITIAL_STATE.totalPrice,
  addToCart: (product) => {
    const cart = get().cart;
    const cartItem = cart.find((item) => item.id === product.id);

    if (cartItem) {
      const updatedCart = cart.map((item) =>
        item.id === product.id ? { ...item, quantity: item.quantity + 1 } : item
      );
      set((state) => ({
        cart: updatedCart,
        totalItems: state.totalItems + 1,
        totalPrice: state.totalPrice + product.price,
      }));
    } else {
      const updatedCart = [...cart, { ...product, quantity: 1 }];

      set((state) => ({
        cart: updatedCart,
        totalItems: state.totalItems + 1,
        totalPrice: state.totalPrice + product.price,
      }));
    }
  },
  removeFromCart: (product) => {
    const cart = get().cart;
    const cartItem = cart.find((item) => item.id === product.id && product.quantity > 1);

    if (cartItem) {
      const updatedCart = cart.map((item) =>
        item.id === product.id ? { ...item, quantity: item.quantity - 1 } : item
      );
      set((state) => ({
        cart: updatedCart,
        totalItems: state.totalItems - 1,
        totalPrice: state.totalPrice - product.price,
      }));
    } else {
      set((state) => ({
        cart: state.cart.filter((item) => item.id !== product.id),
        totalItems: state.totalItems - 1,
        totalPrice: state.totalPrice - product.price,
      }));
    }
  },
}));
