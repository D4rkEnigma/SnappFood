import { ErrorMessage, Form, Formik } from "formik";
import { Input } from "../form/input";
import * as Yup from "yup";

const RestaurantLoginSchema = Yup.object().shape({
  restaurantName: Yup.string().required("نام الزامی است"),
  password: Yup.string().required("رمز عبور الزامی است"),
});

const initialValues = {
  restaurantName: "",
  password: "",
};

export const RestaurantLoginForm = () => {
  return (
    <Formik
      initialValues={initialValues}
      validationSchema={RestaurantLoginSchema}
      onSubmit={async (values) => {
        console.log(values);
      }}
    >
      <Form className="flex flex-col items-center gap-10 w-full">
        <div className="flex flex-col gap-8 w-full">
          <div className="flex flex-col gap-2">
            <Input
              name="restaurantName"
              type="text"
              placeholder="نام رستوران"
            />
            <ErrorMessage
              name="restaurantName"
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
