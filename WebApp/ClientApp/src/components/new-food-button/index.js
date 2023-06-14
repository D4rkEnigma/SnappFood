import { Fragment, useState } from "react";
import { FiPlusSquare } from "react-icons/fi";
import { ErrorMessage, Form, Formik } from "formik";
import { Dialog, Transition } from "@headlessui/react";
import { Input } from "../form/input";
import * as Yup from "yup";

const FoodSchema = Yup.object().shape({
  foodName: Yup.string().required("نام غذا الزامی است"),
  foodPrice: Yup.string().required("قیمت غذا الزامی است"),
});

const initialValues = {
  foodName: "",
  foodPrice: "",
};

export const NewFoodButton = () => {
  const [isOpen, setIsOpen] = useState(false);
  function closeModal() {
    setIsOpen(false);
  }

  return (
    <>
      <button
        onClick={() => setIsOpen(true)}
        className="flex items-center gap-2 rounded-xl border border-orange-400 px-8 py-5"
      >
        <span className="-mt-1">
          <FiPlusSquare />
        </span>
        <span>ایجاد غذای جدید</span>
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
                    ایجاد غذای جدید
                  </Dialog.Title>
                  <div className="mt-10">
                    <Formik
                      initialValues={initialValues}
                      validationSchema={FoodSchema}
                      onSubmit={async (values) => {
                        console.log(values);
                      }}
                    >
                      <Form className="flex flex-col items-center gap-10 w-full">
                        <div className="flex flex-col gap-8 w-full">
                          <div className="flex flex-col gap-2">
                            <Input
                              name="foodName"
                              type="text"
                              placeholder="نام غذا"
                            />
                            <ErrorMessage
                              name="foodName"
                              className="text-sm text-red-500"
                              component="div"
                            />
                          </div>
                          <div className="flex flex-col gap-2">
                            <Input
                              name="foodPrice"
                              type="text"
                              placeholder="قیمت غذا"
                            />
                            <ErrorMessage
                              name="foodPrice"
                              className="text-sm text-red-500"
                              component="div"
                            />
                          </div>
                        </div>
                        <button
                          type="submit"
                          className="w-full h-12 text-white rounded-md px-6 text-lg bg-orange-600"
                        >
                          ایجاد
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