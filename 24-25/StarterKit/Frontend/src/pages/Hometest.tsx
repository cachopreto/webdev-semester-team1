// import React, { useEffect, useState } from 'react';
// import { Link } from 'react-router-dom';

// interface ShowDate {
//   id: number;
//   dateAndTime: string;
// }

// interface Show {
//   showId: number;
//   title: string;
//   description: string;
//   price: number;
//   venue: {
//     name: string;
//     capacity: number;
//   };
//   dates: ShowDate[];
// }

// export default function Home() {
//   const [shows, setShows] = useState<Show[]>([]);
//   const [loading, setLoading] = useState(true);
//   const [error, setError] = useState<string | null>(null);

//   useEffect(() => {
//     const fetchShows = async () => {
//       try {
//         const response = await fetch('/api/v1/reservations/shows');
//         if (!response.ok) {
//           throw new Error('Failed to fetch shows');
//         }
//         const data = await response.json();
//         setShows(data);
//       } catch (err) {
//         setError(err instanceof Error ? err.message : 'An error occurred');
//       } finally {
//         setLoading(false);
//       }
//     };

//     fetchShows();
//   }, []);

//   if (loading) {
//     return <div className="container px-5 my-5">Loading...</div>;
//   }

//   if (error) {
//     return <div className="container px-5 my-5">Error: {error}</div>;
//   }

//   return (
//     <div className="container px-5 my-5">
//       <h1>Theatre Shows</h1>
      
//       <div className="row">
//         {shows.map(show => (
//           <div key={show.showId} className="col-md-6 mb-4">
//             <div className="card">
//               <div className="card-body">
//                 <h5 className="card-title">{show.title}</h5>
//                 <p className="card-text">{show.description}</p>
//                 <p>Price: €{show.price}</p>
//                 <p>Venue: {show.venue.name} (Capacity: {show.venue.capacity})</p>
                
//                 <h6>Available Show Dates:</h6>
//                 <div className="list-group">
//                   {show.dates
//                     .filter(date => new Date(date.dateAndTime) > new Date())
//                     .sort((a, b) => new Date(a.dateAndTime).getTime() - new Date(b.dateAndTime).getTime())
//                     .map(date => (
//                       <Link 
//                         key={date.id}
//                         to={`/reservation/${date.id}`}
//                         className="list-group-item list-group-item-action"
//                       >
//                         {new Date(date.dateAndTime).toLocaleString()}
//                       </Link>
//                     ))
//                   }
//                 </div>
//               </div>
//             </div>
//           </div>
//         ))}
//       </div>
//     </div>
//   );
// }

