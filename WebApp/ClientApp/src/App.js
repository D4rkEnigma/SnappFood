import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import "./index.css";
export const App = () => {
    return (
        <Routes>
          {AppRoutes.map((route, index) => {
            const { element, ...rest } = route;
            return <Route key={index} {...rest} element={element} />;
          })}
        </Routes>
    );
}
