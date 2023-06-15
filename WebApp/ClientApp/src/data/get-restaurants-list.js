import { axios } from "../lib/axios";

export const getRestaurantsList = async () => {
  return axios.get("/Resturant/resturants").then(res => res.data);;
};
