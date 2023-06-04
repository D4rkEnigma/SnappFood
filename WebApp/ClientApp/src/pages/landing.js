import { Link } from "react-router-dom";
import { Signup } from "../components/signup";

export const Landing = () => {
  return <div className="min-h-full w-full max-w-5xl p-10 flex flex-col mx-auto">
    <Link to="/login" className="text-lg text-orange-600 px-6 py-3 border border-orange-700 rounded-md self-start">ورود</Link>
    <div className="w-full flex justify-center">
        <Signup />
    </div>
  </div>;
};
