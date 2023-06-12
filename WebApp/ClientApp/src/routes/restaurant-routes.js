import { Home } from "../pages/restaurant/home";
import { Menu } from "../pages/restaurant/menu";

export const restaurantRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: "/menu",
    element: <Menu />
  }
];
