// main.go
package main

import (
	"net/http"
	"os"
	"time"

	"github.com/gorilla/mux"
	"github.com/rs/zerolog"
	"github.com/rs/zerolog/hlog"

	"zaiboot/golang/infrastructure"
)

//	func Middleware(next http.Handler) http.Handler {
//		return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
//			// do stuff before the handlers
//			next.ServeHTTP(w, r)
//			// do stuff after the hadlers
//			hlog.FromRequest(r).Info().
//				Str("method", r.Method).
//				Stringer("url", r.URL).
//				Int("status", w.).
//				Int("size", size).
//				Dur("duration", duration).
//				Msg("")
//		})
//	}
func handleRequests() {
	zerolog.SetGlobalLevel(zerolog.DebugLevel)
	log := zerolog.New(os.Stdout).With().
		Timestamp().
		Str("appName", "golang-api").
		Str("host", "localhost").
		Logger()
	handlerLogInit := hlog.NewHandler(log)
	globalExceptionFilter := hlog.AccessHandler(func(r *http.Request, status, size int, duration time.Duration) {
		if status == http.StatusInternalServerError {
			hlog.FromRequest(r).Info().
				Str("method", r.Method).
				Stringer("url", r.URL).
				Msg("Se murio")
		}

	})
	myRouter := mux.NewRouter()
	myRouter.Use(handlerLogInit)
	myRouter.HandleFunc("/api/Queue", infrastructure.GetSingleItem).Methods("GET")
	myRouter.HandleFunc("/api/Queue/{id}", infrastructure.CreateNewItem).Methods("PUT")
	myRouter.Use(globalExceptionFilter)

	port := os.Getenv("PORT")

	log.Fatal().Err(http.ListenAndServe(":"+port, myRouter))
}

func main() {
	handleRequests()
}
