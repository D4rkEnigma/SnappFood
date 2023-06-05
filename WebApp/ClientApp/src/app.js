import { Route, Routes } from "react-router-dom";
import { authRoutes } from "./routes/auth-routes";
import { unauthRoutes } from "./routes/unauth-routes";
import { useAuth } from "./context/auth-context";
import "./styles/global.css";

export const App = () => {
  const { user } = useAuth();
  const appRoutes = user ? authRoutes : unauthRoutes;

  return (
    <Routes>
      {appRoutes.map((route, index) => {
        const { element, ...rest } = route;
        return <Route key={index} {...rest} element={element} />;
      })}
    </Routes>
  );
};
