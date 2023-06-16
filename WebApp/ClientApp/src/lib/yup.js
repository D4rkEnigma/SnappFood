import * as Yup from "yup";

Yup.addMethod(Yup.string, "nationalCode", function (errorMessage) {
  return this.test(`nationalCode`, errorMessage, function (value) {
    if (!/^\d{10}$/.test(value)) return false;
    const check = +value[9];
    const sum =
      value
        .split("")
        .slice(0, 9)
        .reduce((acc, x, i) => acc + +x * (10 - i), 0) % 11;
    return sum < 2 ? check === sum : check + sum === 11;
  });
});
export { Yup };
