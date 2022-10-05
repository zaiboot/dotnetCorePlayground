package infrastructure

import (
	"net/http"
	"zaiboot/golang/collections"

	"github.com/gorilla/mux"
	"github.com/rs/zerolog/hlog"
)

var cq *collections.Queue[string] = collections.NewQueue[string]()

func CreateNewItem(w http.ResponseWriter, r *http.Request) {
	vars := mux.Vars(r)
	id := vars["id"]
	cq.Enqueue(id)
	hlog.FromRequest(r).Debug().
		Str("id", id).
		Str("status", "ok").
		Msg("Adding new Id")
}

func GetSingleItem(w http.ResponseWriter, r *http.Request) {
	logger := hlog.FromRequest(r).Debug()
	item, err := cq.Dequeue()

	if err != nil {
		w.WriteHeader(http.StatusNoContent)
		logger.
			Str("status", "NoContent").
			Msg("No ids stored")
	} else {
		w.WriteHeader(http.StatusOK)
		w.Write([]byte(item))
		logger.
			Str("id", item).
			Str("status", "ok").
			Msg("Got new Id")

	}
}
