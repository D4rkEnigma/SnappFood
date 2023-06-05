import { Tab } from "@headlessui/react";
import { UserSignupForm } from "./user-signup-form";
import { RestaurantSignupForm } from "./restaurant-signup-form";
import clsx from "clsx";

export const SignupForms = () => {
  return (
    <div className="w-full max-w-sm px-2 py-16 sm:px-0">
      <Tab.Group>
        <Tab.List className="flex space-x-1 rounded-xl bg-blue-900/20 p-1">
          <Tab
            className={({ selected }) =>
              clsx(
                "w-full rounded-lg py-2.5 text-sm font-medium leading-5 text-blue-700 whitespace-nowrap",
                "ring-white ring-opacity-60 ring-offset-2 ring-offset-blue-400 focus:outline-none focus:ring-2",
                selected
                  ? "bg-white shadow"
                  : "text-blue-100 hover:bg-white/[0.12] hover:text-white"
              )
            }
          >
            ثبت نام کاربر
          </Tab>
          <Tab
            className={({ selected }) =>
              clsx(
                "w-full rounded-lg py-2.5 text-sm font-medium leading-5 text-blue-700 whitespace-nowrap",
                "ring-white ring-opacity-60 ring-offset-2 ring-offset-blue-400 focus:outline-none focus:ring-2",
                selected
                  ? "bg-white shadow"
                  : "text-blue-100 hover:bg-white/[0.12] hover:text-white"
              )
            }
          >
            ثبت نام رستوران
          </Tab>
        </Tab.List>
        <Tab.Panels className="mt-2">
          <Tab.Panel
            className={clsx(
              "rounded-xl bg-white p-3",
              "ring-white ring-opacity-60 ring-offset-2 ring-offset-blue-400 focus:outline-none focus:ring-2"
            )}
          >
            <UserSignupForm />
          </Tab.Panel>
          <Tab.Panel
            className={clsx(
              "rounded-xl bg-white p-3",
              "ring-white ring-opacity-60 ring-offset-2 ring-offset-blue-400 focus:outline-none focus:ring-2"
            )}
          >
            <RestaurantSignupForm />
          </Tab.Panel>
        </Tab.Panels>
      </Tab.Group>
    </div>
  );
};
