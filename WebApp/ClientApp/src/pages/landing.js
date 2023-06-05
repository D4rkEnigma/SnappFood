import { Link } from "react-router-dom";
import { LoginForms } from "../components/login-forms";

export const Landing = () => {
  return (
    <div className="min-h-full w-full max-w-5xl p-10 flex flex-col mx-auto">
      <Link
        to="/signup"
        className="text-lg text-orange-600 px-6 py-2 border border-orange-700 rounded-md self-start"
      >
        ثبت نام
      </Link>
      <div className="w-full flex justify-center">
        <LoginForms />
      </div>
    </div>
  );
};
