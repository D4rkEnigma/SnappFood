import { ErrorMessage, Form, Formik } from "formik";
import { Input } from "../form/input";
import * as Yup from "yup";
import { signupUser } from "../../data/signup-user";

const UserSignupSchema = Yup.object().shape({
  firstName: Yup.string().required("نام الزامی است"),
  lastName: Yup.string().required("نام خانوادگی الزامی است"),
  nationalCode: Yup.string().required("کد ملی الزامی است"),
  address: Yup.string().required("آدرس الزامی است"),
  password: Yup.string()
    .required("رمز عبور الزامی است")
    .min(8, "رمز عبور باید حداقل ۸ کاراکتر باشد"),
  confirmPassword: Yup.string()
    .required("تکرار رمز عبور الزامی است")
    .oneOf([Yup.ref("password"), null], "رمز عبور و تکرار آن باید یکسان باشند"),
});

const initialValues = {
  firstName: "",
  lastName: "",
  nationalCode: "",
  address: "",
  password: "",
  confirmPassword: "",
};

export const UserSignupForm = () => {
  return (
    <Formik
      initialValues={initialValues}
      validationSchema={UserSignupSchema}
      onSubmit={async (values) => {
        await signupUser(values);
        window.location.replace("/");
      }}
    >
      <Form className="flex flex-col items-center gap-10 w-full">
        <div className="flex flex-col gap-8 w-full">
          <div className="flex flex-col gap-2">
            <Input
              name="firstName"
              type="text"
              placeholder="نام"
            />
            <ErrorMessage
              name="firstName"
              className="text-sm text-red-500"
              component="div"
            />
          </div>
          <div className="flex flex-col gap-2">
            <Input
              name="lastName"
              type="text"
              placeholder="نام خانوادگی"
            />
            <ErrorMessage
              name="lastName"
              className="text-sm text-red-500"
              component="div"
            />
          </div>
          <div className="flex flex-col gap-2">
            <Input
              name="nationalCode"
              type="text"
              placeholder="کد ملی"
            />
            <ErrorMessage
              name="nationalCode"
              className="text-sm text-red-500"
              component="div"
            />
          </div>
          <div className="flex flex-col gap-2">
            <Input
              name="address"
              type="text"
              placeholder="آدرس"
            />
            <ErrorMessage
              name="address"
              className="text-sm text-red-500"
              component="div"
            />
          </div>
          <div className="flex flex-col gap-2">
            <Input
              name="password"
              type="password"
              placeholder="رمز عبور"
            />
            <ErrorMessage
              name="password"
              className="text-sm text-red-500"
              component="div"
            />
          </div>
          <div className="flex flex-col gap-2">
            <Input
              name="confirmPassword"
              type="password"
              placeholder="تکرار رمز عبور"
            />
            <ErrorMessage
              name="confirmPassword"
              className="text-sm text-red-500"
              component="div"
            />
          </div>
        </div>
        <button
          type="submit"
          className="w-full h-12 text-white rounded-md px-6 text-lg bg-orange-600"
        >
          ثبت نام
        </button>
      </Form>
    </Formik>
  );
};
