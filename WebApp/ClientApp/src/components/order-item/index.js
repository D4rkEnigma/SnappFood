import { Dialog, Transition } from "@headlessui/react";
import { Fragment, useState } from "react";
import { addOrderToDelivered } from "../../data/add-order-to-delivered";
import { useMutation, useQueryClient } from "react-query";
import { toast } from "react-toastify";

export const OrderItem = ({ order }) => {
  const foodNames = order.orderList
    .map((item) => item.menuItem.foodName)
    .join(" + ");
  const [isOpen, setIsOpen] = useState(false);
  function closeModal() {
    setIsOpen(false);
  }

  const queryClient = useQueryClient();
  const deliverOrderMutation = useMutation(
    ({ cartId }) => {
      return addOrderToDelivered({ cartId });
    },
    {
      onSuccess() {
        toast.success("سفارش با موفقیت تحویل داده شد!", {
          position: toast.POSITION.BOTTOM_RIGHT,
          rtl: true,
        });
        queryClient.invalidateQueries(["restaurant-orders"]);
      },
    }
  );

  return (
    <>
      <div
        role="button"
        onClick={() => setIsOpen(true)}
        className="rounded-lg border border-gray-100 shadow-md px-8 py-5 bg-white cursor-pointer"
      >
        <p className="w-full two-line-ellipsis text-sm">{foodNames}</p>
        <div className="border border-t-gray-300 my-4" />

        <p className="text-sm font-medium text-left">{order.user.name}</p>
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
                    {order.orderList.map((item) => {
                      return (
                        <div
                          key={item.menuItem.menuItemID}
                          className="flex gap-10 justify-between"
                        >
                          <p className="flex-1 truncate">
                            {item.menuItem.foodName}
                          </p>
                          <p className="pl-2">{item.count}</p>
                        </div>
                      );
                    })}
                    <div className="flex flex-col gap-1 border border-gray-300 rounded-sm p-3 mt-4">
                      <p>آدرس: {order.user.address}</p>
                      <p>نام تحویل گیرنده: {order.user.name}</p>
                    </div>
                  </div>
                  <div className="mt-6 flex justify-center">
                    <button
                      onClick={() => {
                        deliverOrderMutation.mutate({ cartId: order.cartID });
                        closeModal();
                      }}
                      className="rounded-md bg-orange-600 px-6 py-2 text-white"
                    >
                      تحویل شد
                    </button>
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
