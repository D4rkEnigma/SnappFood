import { Tab } from "@headlessui/react";
import clsx from "clsx";
import { UserLoginForm } from "./user-login-form";
import { RestaurantLoginForm } from "./restaurant-login-form";

export const LoginForms = () => {
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
            ورود کاربر
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
            ورود رستوران
          </Tab>
        </Tab.List>
        <Tab.Panels className="mt-2">
          <Tab.Panel
            className={clsx(
              "rounded-xl bg-white p-3",
              "ring-white ring-opacity-60 ring-offset-2 ring-offset-blue-400 focus:outline-none focus:ring-2"
            )}
          >
            <UserLoginForm />
          </Tab.Panel>
          <Tab.Panel
            className={clsx(
              "rounded-xl bg-white p-3",
              "ring-white ring-opacity-60 ring-offset-2 ring-offset-blue-400 focus:outline-none focus:ring-2"
            )}
          >
            <RestaurantLoginForm />
          </Tab.Panel>
        </Tab.Panels>
      </Tab.Group>
    </div>
  );
};
