import { ReservationRequest } from "../types/reservation";

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

export const getTheatreShowById = (id: number) => {
  return fetch(`http://localhost:5097/api/v1/theatreShow/GetById?id=${id}`)
    .then((response) => {
      if (!response.ok) {
        throw new Error("Failed to fetch theatre show");
      }
      return response.json();
    })
    .catch((error) => {
      console.error(error);
      throw error;
    });
};

export const updateTheatreShow = (id: number, theatreShow: any) => {
  return fetch(`http://localhost:5097/api/v1/theatreShow/UpdateTheatreShow?id=${id}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(theatreShow),
  })
    .then((response) => {
      if (!response.ok) {
        // If the server returns an error status, throw an error to trigger the `catch` block
        throw new Error("Failed to update theatre show.");
      }
      return response.text(); // Adjust this based on what your API returns (e.g., JSON, plain text)
    });
};

export const deleteTheatreShow = (id: number): Promise<string> => {
  return fetch(`http://localhost:5097/api/v1/theatreShow/DeleteById?id=${id}`, {
    method: "DELETE",
  })
    .then((response) => {
      if (!response.ok) {
        // If the response is not successful, throw an error
        return response.text().then((errorText) => {
          throw new Error(errorText || "Failed to delete theatre show");
        });
      }
      // Return the response message (which should be plain text from your API)
      return response.text();
    })
    .catch((error) => {
      console.error("Error in deleteTheatreShow:", error);
      throw error; // Re-throw the error to be handled outside this function
    });
};


export const fetchShows = (filters: Record<string, string | undefined>): Promise<any[]> => {
  const queryParams = new URLSearchParams(filters as Record<string, string>).toString(); // Build query string
  return fetch(`http://localhost:5097/api/shows?${queryParams}`)
    .then((response) => {
      if (!response.ok) {
        throw new Error("Failed to fetch shows");
      }
      return response.json(); // Parse JSON response
    })
    .catch((error) => {
      console.error("Error fetching shows:", error);
      return []; // Return an empty array in case of error
    });
};

export const fetchVenues = (): Promise<any[]> => {
  return fetch("http://localhost:5097/api/venues")
    .then((response) => {
      if (!response.ok) {
        throw new Error("Failed to fetch venues");
      }
      return response.json(); // Parse JSON response
    })
    .catch((error) => {
      console.error("Error fetching venues:", error);
      return []; // Return an empty array in case of error
    });
};

// services/reservationService.ts

export const createReservation = async (reservationData: ReservationRequest) => {
  const response = await fetch('http://localhost:5000/api/v1/reservations', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(reservationData),
  });

  if (!response.ok) {
    const errorText = await response.text();
    throw new Error(`Failed to reserve: ${errorText}`);
  }

  return await response.json(); // Return JSON response if reservation is successful
};

