import { logoutUser } from "../../data/logout-user";
import { NewFoodButton } from "../../components/new-food-button";
import { useQuery } from "react-query";
import { getRestaurantMenu } from "../../data/get-restaurant-menu";
import { useAuth } from "../../context/auth-context";
import { DateTime } from "luxon";

export const Menu = () => {
  const { user } = useAuth();
  const { name: restaurantName } = user;
  const { data: menuItems, isLoading } = useQuery(
    ["restaurant-menu", { restaurantName }],
    () => getRestaurantMenu({ restaurantName })
  );

  if (isLoading) return null;

  return (
    <div className="min-h-full w-full max-w-5xl p-10 flex flex-col mx-auto">
      <div className="flex justify-between items-stretch">
        <NewFoodButton />
        <button
          onClick={() => logoutUser()}
          className="text-lg text-orange-600 px-6 py-2 border border-orange-700 rounded-md self-start"
        >
          خروج
        </button>
      </div>
      <div className="flex flex-col mt-8 gap-6">
        {menuItems.length === 0 && (
          <p className="text-center">منو خالی است! غذای جدیدی اضافه کنید.</p>
        )}
        {menuItems.length > 0 && (
          <div className="flex flex-col mt-8 gap-6 min-w-[750px]">
            <div className="flex justify-between gap-8 px-8 py-5">
              <p className="flex-1">نام</p>
              <p className="flex-1 text-center">قیمت</p>
              <p className="flex-1 text-center">زمان آماده سازی</p>
            </div>
            {menuItems.map((menuItem) => (
              <div
                key={menuItem.menuItemID}
                className="flex justify-between gap-8 rounded-xl border border-gray-200 shadow-md px-8 py-5"
              >
                <p className="flex-1 truncate">{menuItem.foodName}</p>
                <p className="flex-1 text-center">{menuItem.price} تومان</p>
                <p className="flex-1 text-center">{DateTime.fromISO(menuItem.cookingTime).setLocale('fa').toLocaleString(DateTime.TIME_24_SIMPLE)}</p>
              </div>
            ))}
          </div>
        )}
      </div>
    </div>
  );
};
