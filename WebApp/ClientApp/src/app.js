import { Route, Routes } from "react-router-dom";
import { unauthRoutes } from "./routes/unauth-routes";
import { useAuth } from "./context/auth-context";
import 'react-toastify/dist/ReactToastify.css';
import "./styles/global.css";
import { userRoutes } from "./routes/user-routes";
import { restaurantRoutes } from "./routes/restaurant-routes";

export const App = () => {
  const { user } = useAuth();
  const appRoutes = user ? user.nationalCode ? userRoutes : restaurantRoutes : unauthRoutes;

  return (
    <Routes>
      {appRoutes.map((route, index) => {
        const { element, ...rest } = route;
        return <Route key={index} {...rest} element={element} />;
      })}
    </Routes>
  );
};
