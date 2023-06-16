import { axios } from "../lib/axios";

export const addOrderToDelivered = async ({ cartId }) => {
  return axios.post("Resturant/order-delivered", cartId);
};
