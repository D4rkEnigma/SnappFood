import { Home } from "../pages/home";
import { Restaurant } from "../pages/restaurant";

export const authRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: "restaurants/:restaurantId",
    element: <Restaurant />
  }
];
