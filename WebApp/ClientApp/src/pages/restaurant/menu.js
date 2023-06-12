import { logoutUser } from "../../data/logout-user";
import { NewFoodButton } from "../../components/new-food-button";
import { EditFoodButton } from "../../components/edit-food-button";

const foods = [
  {
    name: "پیتزا ویوا چیکن",
    price: "269000",
  },
  {
    name: "پیتزا کاپری چیوسا",
    price: "269000",
  },
  {
    name: "پیتزا میت لاورز چهار نفره",
    price: "269000",
  },
  {
    name: "مینی مگا(پیتزا فورسیزن)",
    price: "269000",
  },
  {
    name: "باکس برگر",
    price: "269000",
  },
  {
    name: "کویین برگر",
    price: "269000",
  },
  {
    name: "کینگ برگر",
    price: "269000",
  },
  {
    name: "پیتزا دونر",
    price: "269000",
  },
  {
    name: "ساندویچ چیز استیک",
    price: "269000",
  },
];

export const Menu = () => {
  return (
    <div className="min-h-full w-full max-w-5xl p-10 flex flex-col mx-auto">
      <button
        onClick={() => logoutUser()}
        className="text-lg text-orange-600 px-6 py-2 border border-orange-700 rounded-md self-start"
      >
        خروج
      </button>
      <div className="flex flex-wrap mt-8 gap-6">
        {foods.map((food, i) => (
          <div
            key={i}
            className="flex gap-8 rounded-xl border border-gray-200 shadow-md px-8 py-5"
          >
            <div className="flex gap-4">
              <p>{food.name}</p>
              <p>{food.price} تومان</p>
            </div>
            <EditFoodButton food={food} />
          </div>
        ))}
        <NewFoodButton />
      </div>
    </div>
  );
};
