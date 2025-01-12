export const getTheatreShows = async () => {
  try {
    const response = await fetch("http://localhost:5097/api/v1/theatreShow");
    if (!response.ok) {
      throw new Error("Failed to fetch theatre shows");
    }
    return await response.json();
  } catch (error) {
    console.error(error);
    throw error;
  }
};
