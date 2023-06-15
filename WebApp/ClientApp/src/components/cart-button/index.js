import { Transition } from "@headlessui/react";
import { Fragment } from "react";
import { FiMinusCircle, FiPlusCircle, FiShoppingCart } from "react-icons/fi";
import { useCartStore } from "../../store/useCartStore";
import { addUserOrder } from "../../data/add-user-order";
import { useAuth } from "../../context/auth-context";

export const CartButton = () => {
  const {user} = useAuth();
  const store = useCartStore((store) => store);
  const { cart, addToCart, removeFromCart, isCartOpen, toggleCart, reset } = store;

  return (
    <>
      <button
        onClick={() => toggleCart()}
        className="bg-orange-600 rounded-md px-4 py-1"
      >
        <FiShoppingCart strokeWidth={1.5} color="white" size={24} />
      </button>
      <Transition
        as={Fragment}
        enter="ease-out duration-300"
        enterFrom="-translate-x-80"
        enterTo="translate-x-0"
        leave="ease-in duration-200"
        leaveFrom="translate-x-0"
        leaveTo="-translate-x-80"
        show={isCartOpen}
      >
        <div className="fixed top-0 bottom-0 h-full w-80 left-0 overflow-y-auto">
          <div className="min-h-full pt-10 border-r border-r-gray-200">
            {cart.length > 0 ? (
              <div>
                <div>
                  {cart.map((item) => (
                    <div
                      key={item.menuItemID}
                      className="flex justify-between px-4 py-2.5 border-y border-y-gray-200"
                    >
                      <div>
                        <p className="text-sm font-medium">{item.foodName}</p>
                        <p className="mt-1 text-xs">{item.price} تومان</p>
                      </div>
                      <div className="flex items-center gap-2">
                        <button
                          onClick={() => removeFromCart(item)}
                          className="text-orange-600"
                        >
                          <FiMinusCircle strokeWidth={1.5} size={20} />
                        </button>
                        <p className="mt-1">{item.quantity}</p>
                        <button
                          onClick={() => addToCart(item)}
                          className="text-orange-600"
                        >
                          <FiPlusCircle strokeWidth={1.5} size={20} />
                        </button>
                      </div>
                    </div>
                  ))}
                </div>
                <div className="px-4 mt-4">
                  <button onClick={async () => {
                    await addUserOrder({userNationalCode: user.nationalCode, menuItems: cart});
                    reset();
                  }} className="w-full h-12 text-white rounded-md px-6 bg-orange-600">
                    نهایی کردن خرید
                  </button>
                </div>
              </div>
            ) : (
              <div className="p-10">سبد خرید شما خالیست!</div>
            )}
          </div>
        </div>
      </Transition>
    </>
  );
};
