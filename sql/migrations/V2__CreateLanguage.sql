CREATE TABLE public."Languages"(
	"Id" uuid NOT NULL,
	"Name" varchar(50) NOT NULL,
	CONSTRAINT "Pk_LanguageId" PRIMARY KEY ("Id")

);

INSERT INTO public."Languages" ("Id", "Name")
	VALUES (gen_random_uuid(), 'English'),
		   (gen_random_uuid(), 'German'),
		   (gen_random_uuid(), 'French');
