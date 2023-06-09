import { Link, useParams } from "react-router-dom";
import { logoutUser } from "../../data/logout-user";
import { CartButton } from "../../components/cart-button";
import { MenuItem } from "../../components/menu-item";
import { useQuery } from "react-query";
import { getRestaurantMenu } from "../../data/get-restaurant-menu";
import { FiChevronRight } from "react-icons/fi";

export const Restaurant = () => {
  const { restaurantName } = useParams();
  const { data: menuItems, isLoading } = useQuery(
    ["restaurant-menu", { restaurantName }],
    () => getRestaurantMenu({ restaurantName })
  );

  if (isLoading) return null;

  return (
    <div className="min-h-full w-full max-w-5xl p-10 flex flex-col mx-auto">
      <div className="flex gap-4">
        <Link
          to="/"
          className="flex items-center text-lg text-orange-600 px-6 py-2 border border-orange-700 rounded-md"
        >
          <FiChevronRight strokeWidth={1.5} size={24} />
        </Link>
        <button
          onClick={() => logoutUser()}
          className="text-lg text-orange-600 px-6 py-2 border border-orange-700 rounded-md"
        >
          خروج
        </button>
        <div className="flex mr-auto">
          <CartButton />
        </div>
      </div>
      <div className="grid grid-cols-2 gap-6 mt-8">
        {menuItems.map((menuItem) => (
          <MenuItem key={menuItem.menuItemID} menuItem={menuItem} />
        ))}
      </div>
    </div>
  );
};
