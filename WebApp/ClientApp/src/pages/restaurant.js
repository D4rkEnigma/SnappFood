import { useParams } from "react-router-dom";
import foodCover from "../assets/images/food-cover.jpg";
import { FiPlusCircle } from "react-icons/fi";

export const Restaurant = () => {
  const { restaurantId } = useParams();

  return (
    <div className="min-h-full w-full max-w-5xl p-10 flex flex-col mx-auto">
      <button className="text-lg text-orange-600 px-6 py-2 border border-orange-700 rounded-md self-start">
        خروج
      </button>
      <div className="grid grid-cols-2 gap-6 mt-8">
        {Array.from(Array(8)).map((_, i) => {
          return (
            <div
              key={i}
              className="flex gap-3 p-3.5 rounded-lg grow-0 border border-gray-300 hover:shadow-xl hover:-translate-y-0.5 transition-all duration-200"
            >
              <div className="w-24 aspect-square rounded-lg overflow-hidden">
                <img
                  src={foodCover}
                  alt=""
                  className="w-full h-full object-cover"
                />
              </div>
              <div className="flex flex-col justify-around">
                <p className="text-gray-800">کینگ برگر</p>
                <p className="text-sm text-orange-500">269,000 تومان</p>
              </div>
              <button className="text-orange-600 mr-auto self-end">
                <FiPlusCircle strokeWidth={1} size={32} />
              </button>
            </div>
          );
        })}
      </div>
    </div>
  );
};
