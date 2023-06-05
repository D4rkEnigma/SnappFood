import { Landing } from "../pages/landing";
import { Signup } from "../pages/signup";

export const unauthRoutes = [
  {
    index: true,
    element: <Landing />
  },
  {
    path: "/signup",
    element: <Signup />
  }
];
