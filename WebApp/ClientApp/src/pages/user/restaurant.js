import { useParams } from "react-router-dom";
import { logoutUser } from "../../data/logout-user";
import { CartButton } from "../../components/cart-button";
import { Product } from "../../components/product";

const products = [
  { id: 1, name: "کینگ برگر", price: 269000 },
  { id: 2, name: "کینگ برگر", price: 269000 },
  { id: 3, name: "کینگ برگر", price: 269000 },
  { id: 4, name: "کینگ برگر", price: 269000 },
  { id: 5, name: "کینگ برگر", price: 269000 },
  { id: 6, name: "کینگ برگر", price: 269000 },
  { id: 7, name: "کینگ برگر", price: 269000 },
  { id: 8, name: "کینگ برگر", price: 269000 },
];

export const Restaurant = () => {
  const { restaurantId } = useParams();

  return (
    <div className="min-h-full w-full max-w-5xl p-10 flex flex-col mx-auto">
      <div className="flex justify-between">
        <button
          onClick={() => logoutUser()}
          className="text-lg text-orange-600 px-6 py-2 border border-orange-700 rounded-md self-start"
        >
          خروج
        </button>
        <CartButton />
      </div>
      <div className="grid grid-cols-2 gap-6 mt-8">
        {products.map((product) => (
          <Product key={product.id} product={product} />
        ))}
      </div>
    </div>
  );
};
