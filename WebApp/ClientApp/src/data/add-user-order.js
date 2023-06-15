import { axios } from "../lib/axios";

export const addUserOrder = async ({ userNationalCode, menuItems }) => {
  const items = menuItems.map((item) => ({
    cartID: "",
    menuItemID: item.menuItemID,
    price: item.price,
    count: item.quantity,
    isDelivered: false
  }));
  return axios.post("/Cart/register-order", {
    orderItem: items,
    userNationalCode: userNationalCode.trim(),
  });
};
