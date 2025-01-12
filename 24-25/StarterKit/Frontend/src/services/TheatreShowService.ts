export const getTheatreShows = () => {
    return fetch("http://localhost:5097/api/v1/theatreShow")
      .then((response) => {
        if (!response.ok) {
          throw new Error("Failed to fetch theatre shows");
        }
        return response.json(); // Parse the JSON if the response is successful
      })
      .catch((error) => {
        console.error(error); // Catch any errors from the fetch or response processing
        throw error; // Re-throw the error to handle it outside this function
      });
  };
  
export const createTheatreShow = (theatreShow: any) => {
  return fetch("http://localhost:5097/api/v1/theatreShow/PostTheatreShow", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(theatreShow),
  })
    .then((response) => {
      if (!response.ok) {
        throw new Error("Failed to create theatre show");
      }
      return response.json();
    })
    .catch((error) => {
      console.error(error);
      throw error;
    });
};