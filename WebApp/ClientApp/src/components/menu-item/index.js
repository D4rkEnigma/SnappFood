import { FiMinusCircle, FiPlusCircle } from "react-icons/fi";
import foodCover from "../../assets/images/food-cover.jpg";
import { useCartStore } from "../../store/useCartStore";
import clsx from "clsx";

export const MenuItem = ({ menuItem }) => {
  const cart = useCartStore((store) => store.cart);
  const addToCart = useCartStore((store) => store.addToCart);
  const removeFromCart = useCartStore((store) => store.removeFromCart);
  const productInCart = cart.find(
    (prodInCart) => prodInCart.menuItemID === menuItem.menuItemID
  );

  return (
    <div className={clsx("flex gap-3 p-3.5 rounded-lg grow-0 border transition-all duration-200", productInCart ? "border-orange-400" : "border-gray-300 hover:shadow-xl hover:-translate-y-0.5")}>
      <div className="w-24 aspect-square rounded-lg overflow-hidden">
        <img src={foodCover} alt="" className="w-full h-full object-cover" />
      </div>
      <div className="flex flex-col justify-around">
        <p className="text-gray-800">{menuItem.foodName}</p>
        <p className="text-sm text-orange-500">{menuItem.price} تومان</p>
      </div>
      {productInCart ? (
        <div className="flex items-center gap-2 mr-auto self-end">
          <button
            onClick={() => removeFromCart(menuItem)}
            className="text-orange-600"
          >
            <FiMinusCircle strokeWidth={1} size={28} />
          </button>
          <p className="mt-1">{productInCart.quantity}</p>
          <button
            onClick={() => addToCart(menuItem)}
            className="text-orange-600"
          >
            <FiPlusCircle strokeWidth={1} size={28} />
          </button>
        </div>
      ) : (
        <button
          onClick={() => addToCart(menuItem)}
          className="text-orange-600 mr-auto self-end"
        >
          <FiPlusCircle strokeWidth={1} size={32} />
        </button>
      )}
    </div>
  );
};
