import { create } from "zustand";
import { persist } from "zustand/middleware";

const INITIAL_STATE = {
  cart: [],
  totalItems: 0,
  totalPrice: 0,
  isCartOpen: false,
};

export const useCartStore = create(
  persist(
    (set, get) => ({
      cart: INITIAL_STATE.cart,
      totalItems: INITIAL_STATE.totalItems,
      totalPrice: INITIAL_STATE.totalPrice,
      isCartOpen: INITIAL_STATE.isCartOpen,
      addToCart: (product) => {
        const cart = get().cart;
        const cartItem = cart.find(
          (item) => item.menuItemID === product.menuItemID
        );

        if (cartItem) {
          const updatedCart = cart.map((item) =>
            item.menuItemID === product.menuItemID
              ? { ...item, quantity: item.quantity + 1 }
              : item
          );
          set((state) => ({
            cart: updatedCart,
            totalItems: state.totalItems + 1,
            totalPrice: state.totalPrice + product.price,
            isCartOpen: true,
          }));
        } else {
          const updatedCart = [...cart, { ...product, quantity: 1 }];

          set((state) => ({
            cart: updatedCart,
            totalItems: state.totalItems + 1,
            totalPrice: state.totalPrice + product.price,
            isCartOpen: true,
          }));
        }
      },
      removeFromCart: (product) => {
        const cart = get().cart;
        const cartItem = cart.find(
          (item) => item.menuItemID === product.menuItemID && item.quantity > 1
        );

        if (cartItem) {
          const updatedCart = cart.map((item) =>
            item.menuItemID === product.menuItemID
              ? { ...item, quantity: item.quantity - 1 }
              : item
          );
          set((state) => ({
            cart: updatedCart,
            totalItems: state.totalItems - 1,
            totalPrice: state.totalPrice - product.price,
            isCartOpen: true,
          }));
        } else {
          set((state) => ({
            cart: state.cart.filter(
              (item) => item.menuItemID !== product.menuItemID
            ),
            totalItems: state.totalItems - 1,
            totalPrice: state.totalPrice - product.price,
            isCartOpen: true,
          }));
        }
      },
      toggleCart: () => {
        set((state) => ({
          ...state,
          isCartOpen: !state.isCartOpen,
        }));
      },
      reset: () => {
        set(INITIAL_STATE);
      },
    }),
    {
      name: "cart",
    }
  )
);
