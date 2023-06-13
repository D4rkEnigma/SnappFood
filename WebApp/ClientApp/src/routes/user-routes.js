import { Home } from "../pages/user/home";
import { Restaurant } from "../pages/user/restaurant";

export const userRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: "restaurants/:restaurantId",
    element: <Restaurant />
  }
];
