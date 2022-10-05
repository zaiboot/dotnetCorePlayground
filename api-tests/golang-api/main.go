// main.go
package main

import (
	"net/http"
	"os"
	"zaiboot/golang/collections"

	"github.com/gorilla/mux"
	"github.com/rs/zerolog"
	"github.com/rs/zerolog/hlog"
)

var cq *collections.Queue

func createNewItem(w http.ResponseWriter, r *http.Request) {
	vars := mux.Vars(r)
	id := vars["id"]
	cq.Enqueue(id)
	hlog.FromRequest(r).Info().
		Str("id", id).
		Str("status", "ok").
		Msg("Adding new Id")
}

func getSingleItem(w http.ResponseWriter, r *http.Request) {
	item, err := cq.Dequeue()
	if err != nil {
		w.WriteHeader(http.StatusNoContent)
		hlog.FromRequest(r).Info().
			Str("status", "NoContent").
			Msg("No ids stored")
	} else {
		w.WriteHeader(http.StatusOK)
		w.Write([]byte(item))
		hlog.FromRequest(r).Info().
			Str("id", item).
			Str("status", "ok").
			Msg("Got new Id")

	}
}

func handleRequests() {
	zerolog.SetGlobalLevel(zerolog.ErrorLevel)
	log := zerolog.New(os.Stdout).With().
		Timestamp().
		Str("appName", "golang-api").
		Str("host", "localhost").
		Logger()
	handler := hlog.NewHandler(log)
	myRouter := mux.NewRouter()
	myRouter.Use(handler)
	myRouter.HandleFunc("/api/Queue", getSingleItem).Methods("GET")
	myRouter.HandleFunc("/api/Queue/{id}", createNewItem).Methods("PUT")

	port := os.Getenv("PORT")

	log.Fatal().Err(http.ListenAndServe(":"+port, myRouter))
}

func main() {

	cq = collections.New()
	handleRequests()
}
