import { DateTime } from "luxon";

export const timeToIsoDate = (time) => {
  const timePieces = time.split(":");
  const timePaddedWithZero = timePieces
    .map((timePiece) => timePiece.padStart(2, "0"))
    .join(":");
  return DateTime.fromISO(timePaddedWithZero).toISO();
};
