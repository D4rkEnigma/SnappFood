import { ErrorMessage, Form, Formik } from "formik";
import { Input } from "../form/input";
import { loginUser } from "../../data/login-user";
import { Yup } from "../../lib/yup";

const UserLoginSchema = Yup.object().shape({
  nationalCode: Yup.string()
    .required("کد ملی الزامی است")
    .nationalCode("کد ملی وارد شده معتبر نیست."),
  password: Yup.string().required("رمز عبور الزامی است"),
});

const initialValues = {
  nationalCode: "",
  password: "",
};

export const UserLoginForm = () => {
  return (
    <Formik
      initialValues={initialValues}
      validationSchema={UserLoginSchema}
      onSubmit={async (values) => {
        await loginUser(values);
        window.location.replace("/");
      }}
    >
      <Form className="flex flex-col items-center gap-10 w-full">
        <div className="flex flex-col gap-8 w-full">
          <div className="flex flex-col gap-2">
            <Input name="nationalCode" type="text" placeholder="کد ملی" />
            <ErrorMessage
              name="nationalCode"
              className="text-sm text-red-500"
              component="div"
            />
          </div>
          <div className="flex flex-col gap-2">
            <Input name="password" type="password" placeholder="رمز عبور" />
            <ErrorMessage
              name="password"
              className="text-sm text-red-500"
              component="div"
            />
          </div>
        </div>
        <button
          type="submit"
          className="w-full h-12 text-white rounded-md px-6 text-lg bg-orange-600"
        >
          ورود
        </button>
      </Form>
    </Formik>
  );
};
