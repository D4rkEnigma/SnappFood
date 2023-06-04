import { createContext, useContext, useMemo } from "react";

const AuthContext = createContext(undefined);

const getCurrentUser = () => {
  const jsonUser = localStorage.getItem("user");
  return JSON.parse(jsonUser);
};

export const AuthProvider = (props) => {
  const user = useMemo(() => getCurrentUser(), []);
  const value = useMemo(() => ({ user }), [user]);

  return <AuthContext.Provider {...props} value={value} />;
};

export const useAuth = () => {
  const context = useContext(AuthContext);

  if (!context) {
    throw new Error("useAuth must be used within the AuthProvider component.");
  }

  return context;
};
