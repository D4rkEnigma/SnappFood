import { axios } from "../lib/axios";

export const getRestaurantOrders = async ({ restaurantName }) => {
  return axios
    .get(`/Resturant/${restaurantName}/get-restaurant-orders`)
    .then((res) => res.data);
};
