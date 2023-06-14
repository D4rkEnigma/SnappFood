import { Link } from "react-router-dom";
import { logoutUser } from "../../data/logout-user";

export const Home = () => {
  return (
    <div className="min-h-full w-full max-w-5xl p-10 flex flex-col mx-auto">
      <button
        onClick={() => logoutUser()}
        className="text-lg text-orange-600 px-6 py-2 border border-orange-700 rounded-md self-start"
      >
        خروج
      </button>
      <div className="flex mx-auto mt-8">
        <div className="flex flex-col gap-6">
          <Link
            to="/menu"
            className="text-center rounded-xl border border-gray-300 p-4 hover:border-orange-300"
          >
            مشاهده منو
          </Link>
          <Link
            to="/orders"
            className="text-center rounded-xl border border-gray-300 p-4 hover:border-orange-300"
          >
            مشاهده سفارشات
          </Link>
        </div>
      </div>
    </div>
  );
};
