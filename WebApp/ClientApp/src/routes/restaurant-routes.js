import { Home } from "../pages/restaurant/home";
import { Menu } from "../pages/restaurant/menu";
import { Orders } from "../pages/restaurant/orders";

export const restaurantRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: "/menu",
    element: <Menu />
  },
  {
    path: "/orders",
    element: <Orders />
  }
];
