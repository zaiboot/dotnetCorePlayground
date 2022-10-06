package infrastructure

import (
	"net/http"
	"time"

	"github.com/gorilla/mux"
	"github.com/rs/zerolog"
	"github.com/rs/zerolog/hlog"
)

func HandleRequests(l zerolog.Logger) {

	handlerLogInit := hlog.NewHandler(l)
	globalExceptionFilter := hlog.AccessHandler(func(r *http.Request, status, size int, duration time.Duration) {
		if status == http.StatusInternalServerError {
			hlog.
				FromRequest(r).
				Info().
				Str("method", r.Method).
				Stringer("url", r.URL).
				Msg("Se murio")
		}
	})

	myRouter := mux.NewRouter()
	myRouter.Use(handlerLogInit)
	myRouter.HandleFunc("/api/Queue", getSingleItem).Methods("GET")
	myRouter.HandleFunc("/api/Queue/{id}", createNewItem).Methods("PUT")
	myRouter.Use(globalExceptionFilter)

	l.Fatal().Err(http.ListenAndServe(":6020", myRouter))
}
