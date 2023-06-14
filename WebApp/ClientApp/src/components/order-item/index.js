import { Dialog, Transition } from "@headlessui/react";
import { Fragment, useState } from "react";

export const OrderItem = () => {
  const [isOpen, setIsOpen] = useState(false);
  function closeModal() {
    setIsOpen(false);
  }
  
  return (
    <>
      <div
        role="button"
        onClick={() => setIsOpen(true)}
        className="rounded-lg border border-gray-100 shadow-md px-8 py-5 bg-white cursor-pointer"
      >
        <p className="w-full two-line-ellipsis text-sm">
          همبرگر ذغالی + قارچ سوخاری + پیتزا پنیر + دلستر لیمویی
        </p>
        <div className="border border-t-gray-300 my-4" />

        <p className="text-sm font-medium text-left">279000 تومان</p>
      </div>
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
                    جزییات سفارش
                  </Dialog.Title>
                  <div className="flex flex-col gap-3 mt-8">
                    <div className="flex justify-between">
                        <p className="flex-1">نام</p>
                        <p>تعداد</p>
                    </div>
                    {Array.from(Array(5)).map((_, i) => {
                        return (
                            <div key={i} className="flex gap-10 justify-between">
                                <p className="flex-1 truncate">همبرگر ذغالی</p>
                                <p className="pl-2">2</p>
                            </div>
                        )
                    })}
                  </div>
                  <div className="mt-6 flex justify-center">
                    <button className="rounded-md bg-orange-600 px-6 py-2 text-white">تحویل شد</button>
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
