import { Fragment, useState } from "react";
import { FiEdit } from "react-icons/fi";
import { ErrorMessage, Form, Formik } from "formik";
import { Dialog, Transition } from "@headlessui/react";
import { Input } from "../form/input";
import * as Yup from "yup";

const FoodSchema = Yup.object().shape({
  name: Yup.string().required("نام غذا الزامی است"),
  price: Yup.string().required("قیمت غذا الزامی است"),
  cookingTime: Yup.string().required("زمان آماده‌سازی غذا الزامی است"),
});

export const EditFoodButton = ({ food }) => {
  const [isOpen, setIsOpen] = useState(false);
  function closeModal() {
    setIsOpen(false);
  }

  return (
    <>
      <button onClick={() => setIsOpen(true)}>
        <FiEdit />
      </button>
      <Transition appear show={isOpen} as={Fragment}>
        <Dialog as="div" className="relative z-10" onClose={closeModal}>
          <Transition.Child
            as={Fragment}
            enter="ease-out duration-300"
            enterFrom="opacity-0"
            enterTo="opacity-100"
            leave="ease-in duration-200"
            leaveFrom="opacity-100"
            leaveTo="opacity-0"
          >
            <div className="fixed inset-0 bg-black bg-opacity-25" />
          </Transition.Child>

          <div className="fixed inset-0 overflow-y-auto">
            <div className="flex min-h-full items-center justify-center p-4 text-center">
              <Transition.Child
                as={Fragment}
                enter="ease-out duration-300"
                enterFrom="opacity-0 scale-95"
                enterTo="opacity-100 scale-100"
                leave="ease-in duration-200"
                leaveFrom="opacity-100 scale-100"
                leaveTo="opacity-0 scale-95"
              >
                <Dialog.Panel className="w-full max-w-md transform overflow-hidden rounded-2xl bg-white p-6 text-right align-middle shadow-xl transition-all">
                  <Dialog.Title
                    as="h3"
                    className="text-lg font-medium leading-6 text-gray-900"
                  >
                    ویرایش غذا
                  </Dialog.Title>
                  <div className="mt-10">
                    <Formik
                      initialValues={{
                        name: food.name,
                        price: food.price,
                        cookingTime: food.cookingTime
                      }}
                      validationSchema={FoodSchema}
                      onSubmit={async (values) => {
                        console.log(values);
                      }}
                    >
                      <Form className="flex flex-col items-center gap-10 w-full">
                        <div className="flex flex-col gap-8 w-full">
                          <div className="flex flex-col gap-2">
                            <Input
                              name="name"
                              type="text"
                              placeholder="نام غذا"
                            />
                            <ErrorMessage
                              name="name"
                              className="text-sm text-red-500"
                              component="div"
                            />
                          </div>
                          <div className="flex flex-col gap-2">
                            <Input
                              name="price"
                              type="text"
                              placeholder="قیمت غذا"
                            />
                            <ErrorMessage
                              name="price"
                              className="text-sm text-red-500"
                              component="div"
                            />
                          </div>
                          <div className="flex flex-col gap-2">
                            <Input
                              name="cookingTime"
                              type="text"
                              placeholder="زمان آماده‌سازی غذا"
                            />
                            <ErrorMessage
                              name="cookingTime"
                              className="text-sm text-red-500"
                              component="div"
                            />
                          </div>
                        </div>
                        <button
                          type="submit"
                          className="w-full h-12 text-white rounded-md px-6 text-lg bg-orange-600"
                        >
                          ویرایش
                        </button>
                      </Form>
                    </Formik>
                  </div>
                </Dialog.Panel>
              </Transition.Child>
            </div>
          </div>
        </Dialog>
      </Transition>
    </>
  );
};
