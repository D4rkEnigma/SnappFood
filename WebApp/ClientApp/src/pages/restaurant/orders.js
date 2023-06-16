import { useQuery } from "react-query";
import { OrderItem } from "../../components/order-item";
import { logoutUser } from "../../data/logout-user";
import { useAuth } from "../../context/auth-context";
import { getRestaurantOrders } from "../../data/get-restaurant-orders";
import { FiChevronRight } from "react-icons/fi";
import { Link } from "react-router-dom";

export const Orders = () => {
  const { user } = useAuth();
  const { name: restaurantName } = user;
  const { data: orders, isLoading } = useQuery(
    ["restaurant-orders", { restaurantName }],
    () => getRestaurantOrders({ restaurantName })
  );
  if (isLoading) return null;

  return (
    <div className="min-h-full w-full max-w-5xl p-10 flex flex-col mx-auto">
      <div className="flex gap-4 justify-between">
        <Link
          to="/"
          className="flex items-center text-lg text-orange-600 px-6 py-2 border border-orange-700 rounded-md"
        >
          <FiChevronRight strokeWidth={1.5} size={24} />
        </Link>
        <button
          onClick={() => logoutUser()}
          className="text-lg text-orange-600 px-6 py-2 border border-orange-700 rounded-md self-start"
        >
          خروج
        </button>
      </div>
      <div className="mt-8">
        <h1 className="text-xl text-gray-800">لیست سفارشات</h1>
        <div className="restaurant-orders-grid mt-5">
          {orders.map((order) => {
            return <OrderItem key={order.cartID} order={order} />;
          })}
        </div>
      </div>
    </div>
  );
};
