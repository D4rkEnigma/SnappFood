import { Link } from "react-router-dom";
import restaurantCover from "../../assets/images/restaurant-cover.jpg";
import { logoutUser } from "../../data/logout-user";
import { useQuery } from "react-query";
import { getRestaurantsList } from "../../data/get-restaurants-list";
import { DateTime } from "luxon";

export const Home = () => {
  const { data: restaurants, isLoading } = useQuery(["restaurants-list"], () =>
    getRestaurantsList()
  );
  if (isLoading) return null;

  return (
    <div className="min-h-full w-full max-w-5xl p-10 flex flex-col mx-auto">
      <button
        onClick={() => logoutUser()}
        className="text-lg text-orange-600 px-6 py-2 border border-orange-700 rounded-md self-start"
      >
        خروج
      </button>
      <div className="flex flex-wrap justify-center gap-6 mt-8">
        {restaurants.map((restaurant) => {
          return (
            <Link
              key={restaurant.restaurantID}
              to={`restaurants/${restaurant.name}`}
              className="rounded-md overflow-hidden basis-[250px] grow-0 shadow-lg hover:shadow-xl"
            >
              <div className="w-full aspect-[2/1]">
                <img
                  src={restaurantCover}
                  alt=""
                  className="w-full h-full object-cover"
                />
              </div>
              <div className="p-4">
                <p className="text-gray-800 text-lg text-center">
                  {restaurant.name}
                </p>
                <div className="flex flex-col gap-1 text-xs text-center text-gray-600 mt-2">
                  <p>ساعت کاری</p>
                  <p>
                    از ساعت{" "}
                    {DateTime.fromISO(restaurant.openTime)
                      .setLocale("fa")
                      .toLocaleString(DateTime.TIME_24_SIMPLE)}{" "}
                    تا{" "}
                    {DateTime.fromISO(restaurant.closeTime)
                      .setLocale("fa")
                      .toLocaleString(DateTime.TIME_24_SIMPLE)}
                  </p>
                </div>
              </div>
            </Link>
          );
        })}
      </div>
    </div>
  );
};
