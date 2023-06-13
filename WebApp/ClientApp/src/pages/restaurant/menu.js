import { logoutUser } from "../../data/logout-user";
import { NewFoodButton } from "../../components/new-food-button";
import { EditFoodButton } from "../../components/edit-food-button";

const foods = [
  {
    name: "پیتزا ویوا چیکن",
    price: "269000",
    cookingTime: "30",
  },
  {
    name: "پیتزا کاپری چیوسا",
    price: "269000",
    cookingTime: "30",
  },
  {
    name: "پیتزا میت لاورز چهار نفره",
    price: "269000",
    cookingTime: "30",
  },
  {
    name: "مینی مگا(پیتزا فورسیزن)",
    price: "269000",
    cookingTime: "30",
  },
  {
    name: "باکس برگر",
    price: "269000",
    cookingTime: "30",
  },
  {
    name: "کویین برگر",
    price: "269000",
    cookingTime: "30",
  },
  {
    name: "کینگ برگر",
    price: "269000",
    cookingTime: "30",
  },
  {
    name: "پیتزا دونر",
    price: "269000",
    cookingTime: "30",
  },
  {
    name: "ساندویچ چیز استیک",
    price: "269000",
    cookingTime: "30",
  },
];

export const Menu = () => {
  return (
    <div className="min-h-full w-full max-w-5xl p-10 flex flex-col mx-auto">
      <div className="flex justify-between items-center">
        <NewFoodButton />
        <button
          onClick={() => logoutUser()}
          className="text-lg text-orange-600 px-6 py-2 border border-orange-700 rounded-md self-start"
        >
          خروج
        </button>
      </div>
      <div className="flex flex-col mt-8 gap-6">
        {foods.length === 0 && (
          <p className="text-center">منو خالی است! غذای جدیدی اضافه کنید.</p>
        )}
        {foods.length > 0 && (
          <div className="flex flex-col mt-8 gap-6 min-w-[750px]">
            <div className="flex justify-between gap-8 px-8 py-5">
              <p className="flex-1">نام</p>
              <p className="flex-1 text-center">قیمت</p>
              <p className="flex-1 text-center">زمان آماده سازی</p>
              <p className="flex-1 text-left">ویرایش</p>
            </div>
            {foods.map((food, i) => (
              <div
                key={i}
                className="flex justify-between gap-8 rounded-xl border border-gray-200 shadow-md px-8 py-5"
              >
                <p className="flex-1 truncate">{food.name}</p>
                <p className="flex-1 text-center">{food.price} تومان</p>
                <p className="flex-1 text-center">{food.cookingTime} دقیقه</p>
                <div className="flex-1 text-left pl-3">
                  <EditFoodButton food={food} />
                </div>
              </div>
            ))}
          </div>
        )}
      </div>
    </div>
  );
};
