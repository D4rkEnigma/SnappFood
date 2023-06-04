import clsx from "clsx";
import { Field } from "formik";

export const Input = ({ className = "", ...rest }) => {
  return (
    <Field
      className={clsx(
        "min-h-[48px] w-full rounded-t-[5px] border-b border-b-black/50 bg-[#FAFAFA] px-3 focus:outline-none",
        className
      )}
      {...rest}
    />
  );
};
