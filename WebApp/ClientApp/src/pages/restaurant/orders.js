import { OrderItem } from "../../components/order-item";
import { logoutUser } from "../../data/logout-user";

export const Orders = () => {
  return (
    <div className="min-h-full w-full max-w-5xl p-10 flex flex-col mx-auto">
      <button
        onClick={() => logoutUser()}
        className="text-lg text-orange-600 px-6 py-2 border border-orange-700 rounded-md self-start"
      >
        خروج
      </button>
      <div className="mt-8">
        <h1 className="text-xl text-gray-800">لیست سفارشات</h1>
        <div className="restaurant-orders-grid mt-5">
          {Array.from(Array(10)).map((_, i) => {
            return <OrderItem key={i} />
          })}
        </div>
      </div>
    </div>
  );
};
