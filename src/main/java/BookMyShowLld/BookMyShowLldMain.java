package BookMyShowLld;

// Entities

import java.util.List;
import java.util.concurrent.ConcurrentHashMap;
import java.util.function.Function;
import java.util.stream.Collectors;

class Theatre
{
    String name;
    int theatreId;
    List<Screen> screenList;
    String location;
    // has many screens


}

class Screen
{
    String name;
    int screenId;
    // show
    List<Show> showList;

    public void validateShows() {
        return;
    }
    // getScreenInfo();
}

class Show
{
    String name;
    // has a movie playing
    Movie movie;
    String startTime;
    String endTime;

    // has many seats
    List<Seat> seatList;
}

class Seat
{
    String seatType;
    String seatNumber;
    boolean available;
}


class Movie
{
    int id;
    String name;
    // Movie has a list of theatres

    List<Theatre> theatreList;
}


// Theatre controller? or movie?

class TheatreController
{
    // has a list of theatres

    List<Theatre> theatreList;

    // getAllTheatresInLocation(String Location);
    ConcurrentHashMap<Theatre, List<Show>> getAllShows(Movie movie)
    {
//        ConcurrentHashMap<Theatre, List<Show>> x = theatreList.stream()
//                .map(theatre -> {return theatre.screenList.stream()
//                        .map(theatreScreen -> {return theatreScreen.showList.stream()
//                                .filter(show -> show.movie == movie)
//                                        .toList();
//                        }
//                        )
//                        .collect(Collectors.flatMapping());
//                });

        return null;
}

class MovieController
{

    MovieController(){}
    // has list of Movies
    // Theatre -> Movie?

    List<Movie> getMoviesInLocation(String location)
    {
        return null;
    }

}



public class BookMyShowLldMain {
    public static void main(String[] args){
        // first you need to get the list of all movies in a location
        MovieController movieController = new MovieController();
        List<Movie> movies = movieController.getMoviesInLocation("Hyderabad");

        // 2) After selecting a movie -> List down all the theatres and screens
        Movie selectedMovie = movies.getFirst();

        // get the list ofAllTheatres HashMap<Theatre, List<Show>>
        TheatreController theatreController = new TheatreController();
        ConcurrentHashMap<Theatre, List<Show>> listConcurrentHashMap = theatreController.getAllShows(selectedMovie);

        // 3) Get list of shows from Theatre and select the show

        // 4) Select seats from show

        // 5) Payments
    }
}
