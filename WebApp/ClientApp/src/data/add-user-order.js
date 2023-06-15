import { axios } from "../lib/axios";

export const addUserOrder = async ({ userNationalCode, menuItems }) => {
  const items = menuItems.map((item) => ({
    cartID: (Math.random() + 1).toString(36).substring(7),
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
