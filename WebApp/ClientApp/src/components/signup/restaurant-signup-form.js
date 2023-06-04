import { ErrorMessage, Form, Formik } from "formik";
import { Input } from "../form/input";
import * as Yup from "yup";

const RestaurantSignupSchema = Yup.object().shape({
  restaurantName: Yup.string().required("نام الزامی است"),
  ownerName: Yup.string().required("نام خانوادگی الزامی است"),
  address: Yup.string().required("آدرس الزامی است"),
  workHoursFrom: Yup.string().required("شروع ساعت کاری الزامی است"),
  workHoursTo: Yup.string().required("پایان ساعت کاری الزامی است"),
  password: Yup.string()
    .required("رمز عبور الزامی است")
    .min(8, "رمز عبور باید حداقل ۸ کاراکتر باشد"),
  confirmPassword: Yup.string()
    .required("تکرار رمز عبور الزامی است")
    .oneOf([Yup.ref("password"), null], "رمز عبور و تکرار آن باید یکسان باشند"),
});

const initialValues = {
  restaurantName: "",
  ownerName: "",
  address: "",
  workHoursFrom: "",
  workHoursTo: "",
  password: "",
  confirmPassword: "",
};

export const RestaurantSignupForm = () => {
  return (
    <Formik
      initialValues={initialValues}
      validationSchema={RestaurantSignupSchema}
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
            <Input
              name="ownerName"
              type="text"
              placeholder="نام صاحب رستوران"
            />
            <ErrorMessage
              name="ownerName"
              className="text-sm text-red-500"
              component="div"
            />
          </div>
          <div className="flex flex-col gap-2">
            <p>ساعت کارکرد رستوران:</p>
            <div className="flex gap-5">
              <div className="flex flex-col gap-2">
                <Input name="workHoursFrom" type="text" placeholder="از ساعت" />
                <ErrorMessage
                  name="workHoursFrom"
                  className="text-sm text-red-500"
                  component="div"
                />
              </div>
              <div className="flex flex-col gap-2">
                <Input name="workHoursTo" type="text" placeholder="تا ساعت" />
                <ErrorMessage
                  name="workHoursTo"
                  className="text-sm text-red-500"
                  component="div"
                />
              </div>
            </div>
          </div>
          <div className="flex flex-col gap-2">
            <Input name="address" type="text" placeholder="آدرس" />
            <ErrorMessage
              name="address"
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
          className="h-12 border border-orange-300 rounded-md px-6 text-lg text-orange-600"
        >
          ثبت نام
        </button>
      </Form>
    </Formik>
  );
};
