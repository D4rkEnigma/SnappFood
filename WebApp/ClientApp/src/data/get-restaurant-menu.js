import { axios } from "../lib/axios";

export const getRestaurantMenu = async ({restaurantName}) => {
  return axios.get(`/Resturant/${restaurantName}/get-menu`).then(res => res.data);
};
